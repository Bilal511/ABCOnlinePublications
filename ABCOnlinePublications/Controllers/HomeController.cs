using ABCOnlinePublications.Factories;
using ABCOnlinePublications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCOnlinePublications.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dictionary<string, SectionViewModels> _sections;
        private readonly SectionFactory _sectionFactory;

        public HomeController(Dictionary<string, SectionViewModels> sections, SectionFactory sectionFactory)
        {
            _sections = sections;
            _sectionFactory = sectionFactory;
        }

        public IActionResult Index(string section = "preface")
        {
            var sectionData = _sectionFactory.CreateSection(section);
            if (sectionData == null)
            {
                return RedirectToAction("SectionNotFound", new { requestedSection = section });
            }

            return View(sectionData);
        }

        public IActionResult SectionNotFound(string requestedSection)
        {
            var viewModel = new SectionNotFoundViewModels
            {
                RequestedSection = requestedSection
            };

            return View(viewModel);
        }
    }
}