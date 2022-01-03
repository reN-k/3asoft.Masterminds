using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("{pictureId}")]
        public AvatarModel GetPicture(int pictureId)
        {
            AvatarService service = new AvatarService();
            AvatarModel avatar = service.GetPicture(pictureId);

            return avatar;
        }

        [HttpPost]
        public async Task<string> AddFile(IFormFile uploadedFile)
        {
            AvatarService service = new AvatarService();

            if (uploadedFile != null)
            {
                // путь к папке портретов
                string path = AvatarModel.Path + uploadedFile.FileName;
                // сохраняем файл в папку со всеми портретами
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                   await uploadedFile.CopyToAsync(fileStream);
                }
                AvatarModel file = new AvatarModel { Name = uploadedFile.FileName };
                AvatarService.MentorAvatarsList.Add(file);

                return $"{file.Id} - {file.Name} added";
            }

            return "Err";
        }
    }

    
}
