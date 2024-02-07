namespace Znak.ViewModels
{
    public class GeneralViewModel<T>
    {
        public T TEntity { get; set; }

        public IEnumerable<T> TList { get; set; }

        public GeneralViewModel()
        {
            TList = new List<T>();
        }

        public void Add(T model)
        {
            TList.ToList().Add(model);
        }
    }
}
