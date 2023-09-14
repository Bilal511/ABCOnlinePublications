using ABCOnlinePublications.ViewModels;

namespace ABCOnlinePublications.Factories
{
    public class SectionFactory
    {
        private readonly Dictionary<string, SectionViewModels> _sections;
        public SectionFactory(Dictionary<string, SectionViewModels> sections)
        {
            _sections = sections;
        }

        public SectionViewModels? CreateSection(string sectionName)
        {
            if (_sections.TryGetValue(sectionName, out var section))
            {
                return new SectionViewModels
                {
                    Title = section.Title,
                    Content = new List<string>(section.Content),
                    Navigation = new List<NavigationItemViewModels>(section.Navigation)
                };
            }
            return null;
        }
    }
}
