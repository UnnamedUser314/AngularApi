using AutoMapper;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs;
using RestAPI.Models.DTOs.DesignDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class DesignController : BaseController<DesignEntity, DesignDTO, CreateDesignDTO>
    {
        public DesignController(IDesignRepository designsRepository,
            IMapper mapper, ILogger<DesignController> logger)
            : base(designsRepository, mapper, logger)
        {

        }
    }
}
