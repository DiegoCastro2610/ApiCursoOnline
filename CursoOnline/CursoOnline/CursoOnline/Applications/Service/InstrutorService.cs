using CursoOnline.Domains;
using CursoOnline.DTOs.AlunoDto;
using CursoOnline.DTOs.InstrutorDto;
using CursoOnline.Interface;
using static CursoOnline.Exceptions.DomainExcepition;

namespace CursoOnline.Applications.Service
{
    public class InstrutorService
    {
        private readonly IInstrutorRepository _repository;

        public InstrutorService(IInstrutorRepository repository)
        {
            _repository = repository; 
        }

        static private LerInstrutorDto LerDto(INSTRUTOR Instrutor)
        {
            LerInstrutorDto instrutorDto = new LerInstrutorDto
            {
                Nome = Instrutor.Nome,
                AreaDeEspecializacao = Instrutor.AreaDeEspecializacao
            };

            return instrutorDto;
        }

        public List<LerInstrutorDto> Listar()
        {
            List<INSTRUTOR> InstrutorDto = _repository.Listar();
            List<LerInstrutorDto> instrutorDtos = InstrutorDto.Select(I => LerDto(I)).ToList();
            return instrutorDtos;
        }

        public LerInstrutorDto ObterPorAreaDeEspecialicacao(string AreaDeEspecialicacao)
        {
            INSTRUTOR? instrutorDb = _repository.ObterPorAreaDeEspecialicacao(AreaDeEspecialicacao);

            if (instrutorDb == null)
            {
                throw new DomainException("Não Existe essa AreaDeEspecialicaco");
            }

            LerInstrutorDto instrutorDto = LerDto(instrutorDb);

            return instrutorDto;
        }

        public LerInstrutorDto Adicionar(CriarInstrutorDto instrutorDto)
        {
            if (_repository.EspecialicacaoExiste(instrutorDto.AreaDeEspecializacao))
            {
                throw new DomainException("Essa EspecialicacaoExiste");
            }

            INSTRUTOR instrutor = new INSTRUTOR
            {
                Nome = instrutorDto.Nome,
                AreaDeEspecializacao = instrutorDto.AreaDeEspecializacao
            };
            _repository.Adicionar(instrutor);
            return LerDto(instrutor);
        }
    }
}
