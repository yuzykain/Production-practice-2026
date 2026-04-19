using AutosalonWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AutosalonWebAPI.Models
{
    public class ResponceАвтомобили
    {
        public ResponceАвтомобили(Автомобили автомобили)
        {
            ID_Автомобиля = автомобили.id_Автомобиля;
            Марка = автомобили.Марка;
            Поставщик = автомобили.Поставщики.НаименованиеПоставщика;
            Цвет = автомобили.Цвет;
            Количество_мест = автомобили.КоличествоМест;
            Максимальная_скорость = автомобили.МаксимальнаяСкорость;
            Расход_топлива = автомобили.РасходТоплива;
            Цена = (decimal)автомобили.Цена;
            В_наличии = автомобили.ВНаличии;
        }

        public int ID_Автомобиля { get; set; }
        public string Марка { get; set; }
        public string Поставщик { get; set; }
        public string Цвет { get; set; }
        public string Количество_мест { get; set; }
        public string Максимальная_скорость { get; set; }
        public string Расход_топлива { get; set; }
        public decimal Цена { get; set; }
        public string В_наличии { get; set; }


    }
}