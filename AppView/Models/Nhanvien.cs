using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppView // sửa cái này nếu copy nhé
{
    public class Nhanvien
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30,ErrorMessage = "Tên có độ dài không quá 30 kí tự")]
        public string Ten { get; set; }
        [Range(18,50, ErrorMessage = "Tuổi từ 18 đến 30")]
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [EmailAddress(ErrorMessage = "Hãy nhập đúng định dạng email")]
        public string Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "Lương từ 5 đến 30 triệu")]
        public int Luong { get; set; }
        public bool Trangthai { get; set; }
    }
}
