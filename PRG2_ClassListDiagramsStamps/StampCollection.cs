using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_ClassListDiagramsStamps
{
    internal class StampCollection
    {
        private List<Stamps> stamps = new List<Stamps>();

        public void AddStamp(Stamps stamp)
        {
            stamps.Add(stamp);
        }

        public void RemoveStamp(int id)
        {
            Stamps stampToRemove = stamps.Find(s => s.Id == id);
            if (stampToRemove != null)
            {
                stamps.Remove(stampToRemove);
            }
        }

        public List<Stamps> GetStamps()
        {
            return stamps;
        }

        public List<Stamps> SearchStamps(string searchTerm)
        {
            return stamps.FindAll(s =>
                s.Name.Contains(searchTerm) ||
                s.Description.Contains(searchTerm) ||
                s.Motif.Contains(searchTerm)
            );
        }

        public void UpdateStamp(int id, string name, string description, string motif, int year, double priceEvaluation)
        {
            Stamps stampToUpdate = stamps.Find(s => s.Id == id);

            if (stampToUpdate != null)
            {
                stampToUpdate.Name = name;
                stampToUpdate.Description = description;
                stampToUpdate.Motif = motif;
                stampToUpdate.Year = year;
                stampToUpdate.PriceEvaluation = priceEvaluation;
            }
        }

    }
}
