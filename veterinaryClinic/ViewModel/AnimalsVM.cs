using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class AnimalsVM: ViewModelBase
{
    private AnimalsList _animalModel;

    public List<Animal> DisplayAnimals
    {
        get
        {
            return _animalModel._animalsList;
        }
        set
        {
            _animalModel._animalsList = value; OnPropertyChanged();
        }
    }

    public AnimalsVM()
    {
        _animalModel = new AnimalsList();
    }
}