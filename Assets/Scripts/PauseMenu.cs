using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject settingsWindow;
    
    public static bool gameIsPaused = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
       
    }
      void Paused()
        {

            //désactiver le mouvement
            PlayerMovement.instance.enabled = false;
            //activer le menu
            pauseMenuUI.SetActive(true);
            //arrêter le temps
            Time.timeScale = 0;
            //cxharger le statut du jeu
            gameIsPaused = true;
            //ouvrir la fenêtre des paramètres
            settingsWindow.SetActive(false);

        }
      public void Resume()
        {
            //inverse de Paused
            PlayerMovement.instance.enabled = false;

            pauseMenuUI.SetActive(false);
           
            Time.timeScale = 1;
            
            gameIsPaused = false;

        }
     public void LoadMainMenu()
        {
            //Appeler pour éviter de charger les éléments
            DontDestroyOnLoadScene.instance.RemoveFromDestroyOnLoad();
            //Appeler la fonction Resume pour remettre le timeScale à 1
            Resume();
            //Chargement de la scène
            SceneManager.LoadScene("MainMenu");
        }




    
    public void SettingsButton()
    {
        
        settingsWindow.SetActive(true);
       
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
 
}
