using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    public class GendersController : Controller
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GendersController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await _genderRepository.GetGendersAsync();
            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<Gender>>(genderList));
        }
    }
}
