using System.IO;

namespace project_RoleTopMVC.ViewModels
{
    public class GaleriaViewModel : BaseViewModel
    {
        // private const string PATH = "wwwroot/photos-gallery";
        public string[] Photos {get;set;}
        public GaleriaViewModel()
        {
            Photos = Directory.GetFiles("wwwroot/photos-gallery");
            for(int i = 0 ; i < Photos.Length ; i++)
            {
                Photos[i] = Photos[i].Replace("wwwroot/photos-gallery\\", "/photos-gallery");
            }
        }
    }
}