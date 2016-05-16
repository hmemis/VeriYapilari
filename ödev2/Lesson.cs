using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VY13253039Odev2
{
    class Lesson
    {
        int final;

        public int Final
        {
            get { return final; }
            set { final = value; }
        }
        string lessonName;

        public string LessonName
        {
            get { return lessonName; }
            set { lessonName = value; }
        }
        int vize;

        public int Vize
        {
            get { return vize; }
            set { vize = value; }
        }

        public Lesson(string lessonName, int vize, int final)
        {
            this.lessonName = lessonName;
            this.vize = vize;
            this.final = final;

        }



    }
}
