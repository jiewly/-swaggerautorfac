using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MasterMovie
    {

        public int Id { get; set; } //get ให้คนอื่นอ่านค่าได้ setให้คนอื่นเพิ่มค่ามันได้
        public string Title { get; set; }
        public string ImgLink { get; set; }

        public string Time { get; set; }
        public string Date { get; set; }

        public string Type { get; set; }
    }
}
