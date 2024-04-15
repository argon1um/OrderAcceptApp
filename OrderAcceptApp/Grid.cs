using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAcceptApp
{
    internal class Grid
    {
        public Grid(int id, string name, string surname, string patronymic, string service, string theme, string date, string descr, string answer)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.service = service;
            this.theme = theme;
            this.date = date;
            this.descr = descr;
            this.answer = answer;

        }
        public int id {  get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string service { get; set; }
        public string theme { get; set; }
        public string date { get; set; }
        public string descr { get; set; }
        public string answer { get; set; }

        
    }
}
