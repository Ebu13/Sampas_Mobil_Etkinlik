using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AuthBusiness(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<LoginResponse> LoginKontrol(LoginRequest request)
        {
            var output = await _repository.LoginKontrol(request);
            return new LoginResponse(_mapper.Map<LoginDto>(output));
        }
    }
}
