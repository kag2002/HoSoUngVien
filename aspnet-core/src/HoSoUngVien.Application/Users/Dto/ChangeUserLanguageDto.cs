using System.ComponentModel.DataAnnotations;

namespace HoSoUngVien.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}