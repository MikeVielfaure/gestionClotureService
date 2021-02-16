using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace gestionClotureService
{
  /// <summary>
  /// Cette classe modifie l'état des fiche de frais de la base de données
  /// </summary>
  public partial class Service1 : ServiceBase
  {
    // proprietes
    private string chaineConnexion = "server=mysql-saisiedevosfrais.alwaysdata.net;user id=226360;password=saisiedevosfrais;database=saisiedevosfrais_suivisdevosfrais;SslMode=required";
    private const String ETAT_CL = "CR";//CL
    private const String ETAT_RB = "RB";//RB
    private Timer timer = new Timer();

    /// <summary>
    /// initialise le composant
    /// </summary>
    public Service1()
    {
      InitializeComponent();
    }

    /// <summary>
    /// méthode lue au démarrage du service
    /// </summary>
    protected override void OnStart(string[] args)
    {
      Start(args);
    }

    /// <summary>
    /// méthode lue au démarrage du service
    /// </summary>
    internal void Start(string[] args)
    {
      this.timer.Interval = 60000; //60 sec
      this.timer.Elapsed += new ElapsedEventHandler(this.timer_Tick);
      timer.Enabled = true;
      //met a jours l'état des fiches de frais du précédent la date actuelle
      nouveauStatut();
    }

    ///<summary>
    /// change le statut des fiches de frais selon la date actuel
    ///</summary>
    private void nouveauStatut()
    {
      // on vérifie si le jour actuel est entre le premier et le 10
      if (GestionDate.entre(1, 19))
      {
        // on change l'état des fiches de frais du mois précédent avec l'état CL
        changeStatutFicheFrais(ETAT_CL, GestionDate.getMoisPrecedent());
      }
      else
      {
        // on vérifie si le jour actuel est entre le 20 et le dernier jours du mois
        if (GestionDate.entre(20, 31))
        {
          // on change l'état des fiches de frais du mois précédent avec l'état RB
          changeStatutFicheFrais(ETAT_RB, GestionDate.getMoisPrecedent());
        }
      }
    }

    ///<summary>
    /// change le statut des fiches de frais avec l'état et au mois mis en paramètre
    ///</summary>
    ///<param name="etat">etat qu'on veut affecter aux fiche de frais</param>
    ///<param name="leMois">le mois qui correspond au fiche de frais a modifier</param>
    private void changeStatutFicheFrais(String etat, String leMois)
    {
      ConnexionSQL crs = new ConnexionSQL(this.chaineConnexion);
      crs.req("UPDATE fichefrais SET idetat='" + etat + "' WHERE mois ='" + leMois + "'");
      crs.close();
    }

    ///<summary>
    ///A Chaque minute met a jour l'état des fiches de frais
    ///</summary>
    public void timer_Tick(object sender, ElapsedEventArgs e)
    {
      //met a jours l'état des fiches de frais du précédent la date actuelle
      nouveauStatut();
    }

    ///<summary>
    ///se lance à l'arrêt du service
    ///</summary>
    protected override void OnStop()
    {

    }
  }
}
