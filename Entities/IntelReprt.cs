using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MalshinonProject.Entities
{
    internal class IntelReprt
    {
        public int ID { get; set; }
        public int ReporterID { get; set; }

        public int TargetID { get; set; }
        public string Text { get; set; }
        public string TimeStamp { get; set; }


        public IntelReprt(int ID, int ReporterID, int TargetID, string Text, string TimeStamp)
        {
            this.ID = ID;
            this.ReporterID = ReporterID;
            this.TargetID = TargetID;
            this.Text = Text;
            this.TimeStamp = TimeStamp;
        }
    }
}
