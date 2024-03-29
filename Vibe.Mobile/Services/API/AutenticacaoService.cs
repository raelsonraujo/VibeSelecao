﻿using System.Threading.Tasks;
using Vibe.Domain.Model.Input;
using Vibe.Domain.Model.Output;
using Vibe.Domain.Services;

namespace Vibe.Mobile.Services.API
{
    public class AutenticacaoService : BaseService, IAutenticacaoService
    {
        public async Task<AutenticacaoOutput> Autenticacao(AutenticacaoInput input)
        {
            var output = await Read<AutenticacaoOutput>(await http.Client.PostAsync(GetEndpoint(), GetJsonContent(input)));

            // Caso existe uma chave de retorno, definir como header padrão do HttpService
            if (!string.IsNullOrWhiteSpace(output?.Chave))
                http.SetBearer(output.Chave);

            return output;
        }
    }
}
