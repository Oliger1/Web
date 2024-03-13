using WebOliger.Models;

namespace WebOliger.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string DownlowadLink { get; private set; }

        public void AddDocument(IFormFile file, string description, string title, int Id, string categories)
        {
            {
                var Doc = new ResumeModel
                {   
                    Id = Id,
                    Title = title,
                    Description = description,
                    DownloadLink = DownlowadLink,
                    UploadedDocumentsPaths = new List<string>(),

                };

                _context.Add(Doc);
                _context.SaveChanges();
            }
        }
    }
}
