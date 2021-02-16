using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Sql;

namespace gestionClotureService
{
  /// <summary>
  /// Cette classe permet l'envoit de requête sql à la base de donnée mise en paramètre du constructeur
  /// </summary>
  class ConnexionSQL
  {
    // propriétés
    private bool finCurseur = true; // fin du curseur atteinte
    private MySqlConnection connection; // chaine de connexion
    private MySqlCommand command; // envoi de la requête à la base de données
    private MySqlDataReader reader; // gestion du curseur

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="chaineConnection">chaine aves les paramètres de connexion a la base de données</param>
    public ConnexionSQL(string chaineConnection)
    {
      this.connection = new MySqlConnection(chaineConnection);
      this.connection.Open();
    }

    /// <summary>
    /// execution d'une requete select
    /// </summary>
    /// <param name="chaineRequete">chaine avec la requête a exécuter</param>
    public void reqSelect(string chaineRequete)
    {
      this.command = new MySqlCommand(chaineRequete, this.connection);
      this.reader = this.command.ExecuteReader();
      this.finCurseur = false;
      this.suivant();
    }

    /// <summary>
    /// execution d'une requete UPDATE, DELETE, INSERT INTO...
    /// </summary>
    /// <param name="chaineRequete">chaine avec la requête a exécuter</param>
    public void req(string chaineRequete)
    {
      this.command = new MySqlCommand(chaineRequete, this.connection);
      this.command.ExecuteNonQuery();
      this.finCurseur = true;
    }

    /// <summary>
    /// récupération d'un champ
    /// </summary>
    /// <param name="nomChamp">le champs pour lequel on désir la donnée</param>
    /// <returns>la donnée du champ</returns>
    public Object champ(string nomChamp)
    {
      return this.reader[nomChamp];
    }

    /// <summary>
    /// passage à la ligne suivante du curseur
    /// </summary>
    public void suivant()
    {
      if (!this.finCurseur)
      {
        this.finCurseur = !this.reader.Read();
      }
    }

    /// <summary>
    ///  test de la fin du curseur
    /// </summary>
    /// <returns>vrai ou faux</returns>
    public Boolean fin()
    {
      return this.finCurseur;
    }

    /// <summary>
    /// fermeture de la connexion
    /// </summary>
    public void close()
    {
      this.connection.Close();
    }
  }
}
