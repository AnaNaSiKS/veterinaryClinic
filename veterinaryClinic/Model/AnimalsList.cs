namespace veterinaryClinic.Model;

public class AnimalsList
{
    public List<Animal> _animalsList {
        get { return OpenConnectionDataBase.GetInstance().Animals.ToList();}
        set { _animalsList = value; }
    }

    public AnimalsList()
    {
        _animalsList = OpenConnectionDataBase.GetInstance().Animals.ToList();
    }
}