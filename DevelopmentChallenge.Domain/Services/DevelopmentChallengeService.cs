using AutoMapper;
using DevelopmentChallenge.Domain.Command;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Domain.Interfaces.Repositories;
using DevelopmentChallenge.Domain.Interfaces.Services;
using DevelopmentChallenge.Domain.Queries.Result;
using DevelopmentChallenge.Domain.View;

namespace DevelopmentChallenge.Domain.Servicesss
{
    public class DevelopmentChallengeService : IDevelopmentChallengeService
    {
        private IDevelopmentChallengeRepository _developmentChallengeRepository;

        private IMapper _mapper;
        public DevelopmentChallengeService(IDevelopmentChallengeRepository developmentChallengeRepository, IMapper mapper)
        {
            _developmentChallengeRepository = developmentChallengeRepository;
            _mapper = mapper;
        }

        public GenericCommandResult calculateValue(DevelopmentChallengeCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Ops! Algo deu errado.", command.Notifications);

            var rate = _developmentChallengeRepository.SearchRate(command.Tipo!, command.Bandeira!, command.Adquirente!);
            if (rate == 0) return new GenericCommandResult(false, "Desculpe, aliquota não localizada.");

            var result = (command.Valor - ((rate / 100) * command.Valor));

            return new GenericCommandResult(true, "Calculo realizado com sucesso.", new
            {
                ValorLiquido = Math.Round(result!.Value, 2)
            });
        }

        public GenericCommandResult GetAll()
        {
            IEnumerable<MDRQueryResult> mdrs = _developmentChallengeRepository.GetAllMDR();

            if (mdrs.Count() == 0 || mdrs == null) return new GenericCommandResult(false, "Não foi possivel concluir a operação!");

            List<Taxa> taxas = new List<Taxa>();
            taxas = _developmentChallengeRepository.GetlAllTaxa().ToList();

            if (taxas.Count() == 0 || taxas == null) return new GenericCommandResult(false, "Não foi possivel concluir a operação!");

            foreach (var mdr in mdrs)
            {
                mdr.Taxas = taxas.Where(taxa => taxa.MDRId == mdr.Id).ToList();
            }
            var result = new List<ViewMDR>();

            foreach (var mdr in mdrs)
            {
                result.Add(_mapper.Map<ViewMDR>(mdr));
            }
            return new GenericCommandResult(true, "Registros localizados com sucesso", result);
        }
    }
}