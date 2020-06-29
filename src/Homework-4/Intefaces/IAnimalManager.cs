using Homework_4.Models;

namespace Homework_4.Intefaces
{
    interface IAnimalManager
    {
        public void Rename(Animal animal, string name);
        public void GetInfo(Animal animal);
        void SetPassport(Animal animal, string passport);
    }
}
