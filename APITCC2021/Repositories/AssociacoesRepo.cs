using APITCC2021.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITCC2021.Repositories
{
    public class AssociacoesRepo
    {
        private readonly Context _context;
        public AssociacoesRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAssociacoes(List<int> sintomasList)
        {
            //Buscar as associacoes dos sintoma
            var query = from item in _context.AssociacaoDoencasSintomas
                        where sintomasList.Contains(item.SintomaId)
                        select item;

            var resp = await query.ToListAsync();

            //incluir as doencas de cada associacao
            var doencas = new List<dynamic>();
            foreach (var associacao in resp)
            {
                string nome;
                if (associacao.DoencaId == 1)
                {
                    nome = "Febre Amarela";
                }
                else if (associacao.DoencaId == 2)
                {
                    nome = "Covid-19";
                }
                else if (associacao.DoencaId == 3)
                {
                    nome = "H1N1";
                }
                else if (associacao.DoencaId == 4)
                {
                    nome = "Gripe";
                }
                else
                {
                    nome = "Dengue";
                }

                doencas.Add(nome);
            }

            //Quantidade total da lista de doencas
            var total = doencas.Count();

            //ver quantas vezes cada doenca aparece na lista
            var vezesPorDoenca = new List<string>();
            foreach (var doenca in doencas)
            {
                var count = doencas.Where(x => x.Equals(doenca)).Count();
                var porcentagem = (count * 100) / total;
                vezesPorDoenca.Add(doenca + ": " + porcentagem);
            }

            //Gerar lista sem dados repetidos
            List<string> uniqueList = vezesPorDoenca.Distinct().ToList();
            return uniqueList;
        }
    }
}
