using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_ClassListDiagramsStamps
{
    internal class Stamps
    {
        // medlemsvariabler
        private static int nextId = 1;

        private int id;
        private string? name;
        private string? description;
        private string? motif; // frågetecknet efter string betyder nullable.
        private int year;
        private double priceEvaluation;

        // specialmetod 1: konstruktor
        public Stamps(string name, string description, int year)
        {
            // motif används inte här, stringen kan bli utan värde. Därför frågetecknet i deklarationen. 
            this.id = nextId++;
            this.name = name;
            this.description = description;
            this.year = year;
        }

        //specialmetod 2: egenskaper
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Motif
        {
            get { return motif; }
            set { motif = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        //metoder
        public double PriceEvaluation
        {
            get { return priceEvaluation; }
            set { priceEvaluation = value; }
        }
    }
}
