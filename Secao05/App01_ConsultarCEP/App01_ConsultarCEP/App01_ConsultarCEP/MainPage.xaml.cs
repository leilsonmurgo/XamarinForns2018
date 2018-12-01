using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnConsultar.Clicked += BuscarCep;

        }
        private void BuscarCep(object sender, EventArgs args)
        {
            string cepDigitado = txtCep.Text.Trim();
            if (isValidCEP(cepDigitado)) {
                try
                {
                    Endereco e = ViaCepServico.BuscarEnderecoViaCep(cepDigitado);
                    if (e == null)
                    {
                        lblResultado.Text = string.Format("Endereco: {3} {0}, {1} {2}", e.localidade, e.uf, e.logradouro, e.bairro);
                    } else
                    {
                        DisplayAlert("Erro", "Cep não foi encontrado", "OK");
                    }
                    

                } catch (Exception e)
                {
                    DisplayAlert("Erro", "Ocorreram falhas na consulta do CEP", "OK");
                }

            } else
            {
                DisplayAlert("Erro", "Cep digitado é inválido!", "OK");
            }
        }

        private Boolean isValidCEP(string cep)
        {
            Boolean retorno = true;
            if (cep.Length != 8)
            {
                retorno = false;
            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                retorno = false;
            }
            return retorno;
        }

    }
}
