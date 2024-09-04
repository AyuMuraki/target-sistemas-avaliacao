using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Target_v1.Models;
using Target_v1.Services;
using System.Drawing;


namespace Target_v1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TargetTesteController : ControllerBase
    {
        [HttpGet]
        [Route("/exercicio_1")]
        public int Get()
        {
            int INDICE = 13, SOMA = 0, K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            return SOMA; //91
        }

        [HttpGet]
        [Route("/exercicio_2/{valor}")]
        public string GetFibonacci(int valor)
        {
            if (valor == 1 || valor == 0)
                return " Pertence a sequencia de Fibonacci";

            List<int> IniFibonacci = new List<int>() { 0, 1 };
            while (IniFibonacci[IniFibonacci.Count - 1] < valor)
            {
                int proximoValor = IniFibonacci[IniFibonacci.Count - 1] + IniFibonacci[IniFibonacci.Count - 2];
                IniFibonacci.Add(proximoValor);
            }

            if (IniFibonacci.Any(p => p == valor))
            {
                return "Pertence a sequencia ";
            }
            else
            {
                return "Não Pertence a sequencia ";
            }
        }

        [HttpGet]
        [Route("/exercicio_3")]
        public ExercicioTresResponseModel GetExercicioTres()
        {
            List<FaturamentoDiario> diarios = LerArquivoServices.LerArquivo();
            //O menor valor de faturamento ocorrido em um dia do mês;
            var menorvalorfat = diarios.Where(d => d.valor > 0).Min(p => p.valor);
            var maiorvalorfat = diarios.Max(p => p.valor);
            var mediamensal = diarios.Where(d => d.valor > 0).Sum(p => p.valor) / diarios.Where(d => d.valor > 0).Count();
            var numeroDias = diarios.Where(d => d.valor > mediamensal && d.valor > 0).Count();
            ExercicioTresResponseModel resposta = new ExercicioTresResponseModel()
            {
                MaiorValorFat = maiorvalorfat,
                MenorValorFat = menorvalorfat,
                NumeroDias = numeroDias
            };
            return resposta;
        }

        [HttpGet]
        [Route("/exercicio_4")]
        public List<Filial> GetExercicioQuatro()
        {
            Distribuidora distribuidora = new Distribuidora
            {
                listaFiliais = new List<Filial>()
                {
                    new Filial
                    {
                        estado = "SP",
                        porcentagem = 0,
                        valor = 67836.43
                    },
                    new Filial
                    {
                        estado = "RJ",
                        porcentagem = 0,
                        valor = 36678.66
                    },
                    new Filial
                    {
                        estado = "MG",
                        porcentagem = 0,
                        valor = 29229.88
                    },
                    new Filial
                    {
                        estado = "ES",
                        porcentagem = 0,
                        valor = 27165.48
                    },
                     new Filial
                    {
                        estado = "Outros",
                        porcentagem = 0,
                        valor = 19849.53
                    }
                }
            };
            //somando
            distribuidora.totalFaturamento = distribuidora.listaFiliais.Sum(fi => fi.valor);

            foreach(Filial filial in distribuidora.listaFiliais)
            {
                filial.porcentagem = Math.Round(((filial.valor / distribuidora.totalFaturamento) * 100), 2);
            }

            return distribuidora.listaFiliais;
        }

        [HttpGet]
        [Route("/exercicio_5/{str}")]
        public string GetStringAoContrario(string str)
        {
            char[] caracteres = str.ToCharArray();
            int inicio = 0;
            int fim = caracteres.Length - 1;

            while (inicio < fim)
            {
                char temp = caracteres[inicio];
                caracteres[inicio] = caracteres[fim];
                caracteres[fim] = temp;
                inicio++;
                fim--;
            }

            return new string(caracteres);
        }
    }
}
