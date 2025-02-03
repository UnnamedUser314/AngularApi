using AutoMapper;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.DesignDTO;
using RestAPI.Models.DTOs.PujaDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class PujaController : BaseController<PujaEntity, PujaDTO, CreatePujaDTO>
    {
        public PujaController(IPujaRepository pujaRepository,
            IMapper mapper, ILogger<PujaController> logger)
            : base(pujaRepository, mapper, logger)
        {

        }
    }
}
