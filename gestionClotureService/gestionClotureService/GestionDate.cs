using System;

namespace gestionClotureService
{
  /// <summary>
  /// Cette classe permet de gérer des fonctionnalitées qui ont un rapport avec la date
  /// </summary>
  public abstract class GestionDate
  {
    /// <summary>
    /// renvoit le numéro du mois précédent la date d'aujourd'hui sous forme "xx"
    /// </summary>
    /// <returns>le mois précédent la date actuelle</returns>
    public static string getMoisPrecedent()
    {
      // récupération de la date d'aujourd'hui
      DateTime laDate = DateTime.Today;
      // récupère le mois
      int leMois = laDate.Month;
      // récupére et retourne le mois précédent
      return moisPrecedent(leMois);
    }

    /// <summary>
    /// renvoit le numéro du mois précédent une date sous forme "xx"
    /// </summary>
    /// <param name="laDate">la date pour laquelle on veut le mois précédent</param>
    /// <returns>le mois précédent une date</returns>
    public static string getMoisPrecedent(DateTime laDate)
    {
      // récupère le mois
      int leMois = laDate.Month;
      // récupére et retourne le mois precedent
      return moisPrecedent(leMois);
    }

    /// <summary>
    /// renvoit le numéro du mois suivant la date d'aujourd'hui sous forme "xx"
    /// </summary>
    /// <returns>le mois suivant la date actuelle</returns>
    public static string getMoisSuivant()
    {
      // récupération de la date d'aujourd'hui
      DateTime laDate = DateTime.Today;
      // récupère le mois
      int leMois = laDate.Month;
      // récupére et retourne le mois suivant
      return moisSuivant(leMois);
    }

    /// <summary>
    /// renvoit le numéro du mois suivant une date sous forme "xx"
    /// </summary>
    /// <returns>le mois suivant une date</returns>
    public static string getMoisSuivant(DateTime laDate)
    {
      // récupère le mois
      int leMois = laDate.Month;
      // récupére et retourne le mois suivant
      return moisSuivant(leMois);
    }

    /// <summary>
    /// vérifie si le jour d'aujourd'hui se situ entre les deux jours mis en paramètre
    /// </summary>
    /// <param name="jour1">premier jour de l'intervalle</param>
    /// <param name="jour2">deuxième jour de l'intervalle</param>
    /// <returns>vrai ou faux</returns>
    public static bool entre(int jour1, int jour2)
    {
      // récupère le jour d'aujourd'hui
      DateTime laDate = DateTime.Today;
      int leJour = laDate.Day;
      // vérifie et retourne si le jour se situ entre les deux jours en paramètre
      return (leJour >= jour1 && leJour <= jour2);
    }


    /// <summary>
    /// vérifie si un jour se situ entre les deux jours mis en paramètre
    /// </summary>
    /// <param name="jour1">premier jour de l'intervalle</param>
    /// <param name="jour2">deuxième jour de l'intervalle</param>
    /// <param name="laDate">le jour qu'on veut vérifier</param>
    /// <returns>vrai ou faux</returns>
    public static bool entre(int jour1, int jour2, DateTime laDate)
    {
      // récupère le jour de la date en paramètre
      int leJour = laDate.Day;
      // vérifie et retourne si le jour se situ entre les deux jours en paramètre
      return (leJour >= jour1 && leJour <= jour2);
    }

    /// <summary>
    /// méthode qui retourne le mois précédent celui mis en paramètre sous forme "xx"
    /// </summary>
    /// <param name="leMois">le mois pour lequelle on veut son précédent</param>
    /// <returns>le mois précédent sous forme "xx"</returns>
    private static String moisPrecedent(int leMois)
    {
      // vérifie si le mois est janvier dans ce cas faudra le mois précédent sera décembre donc 12
      if (leMois == 1)
      {
        return "12";
      }
      else
      {
        // vérifie si le mois est antérieur à octobre dans ce cas on rajoute un '0' devant
        if (leMois < 10)
        {
          return ("0" + (leMois - 1).ToString());
        }
        else
        {
          return (leMois - 1).ToString();
        }
      }
    }


    /// <summary>
    /// méthode qui retourne le mois suivant celui mis en paramètre sous forme "xx"
    /// </summary>
    /// <param name="leMois">le mois pour lequelle on veut son suivant</param>
    /// <returns>le mois suivant sous forme "xx"</returns>
    private static String moisSuivant(int leMois)
    {
      // vérifie si le mois est décembre dans ce cas faudra le mois suivant sera janvier donc 01
      if (leMois == 1)
      {
        return "01";
      }
      else
      {
        // vérifie si le mois suivant est antérieur à octobre dans ce cas on rajoute un '0' devant
        if (leMois + 1 < 10)
        {
          return ("0" + (leMois + 1).ToString());
        }
        else
        {
          return (leMois + 1).ToString();
        }
      }
    }


  }
}

