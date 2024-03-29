﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const inputCEP = document.getElementById('inputCEP')
const inputRua = document.getElementById('inputRua')
const inputCidade = document.getElementById('inputCidade')
const inputBairro = document.getElementById('inputBairro')
const inputEstado = document.getElementById('inputEstado')


inputCEP.addEventListener('change', (e) => {
    CEP = e.target.value
    console.log(CEP)

    if (CEP.length == 8) {
        BuscaCep(CEP)
    }

    else{
        inputRua.value = ""
        inputCidade.value = ""
        inputBairro.value = ""
        inputEstado.value = ""
    }
});


async function BuscaCep(CEP) {

    const APIfetch = await fetch(`https://brasilapi.com.br/api/cep/v1/${CEP}`)
    const API = await APIfetch.json()
    console.log(API)

    inputRua.value = API.street;
    inputCidade.value = API.city;
    inputBairro.value = API.neighborhood;
    inputEstado.value = API.state;

}


//função para alterar exibição do formulário de plano





function onChangePlanos(){
    const formCarro = document.getElementById('formSeguroCarro')
    const formCasa = document.getElementById('formSeguroCasa')
    const SelectPlano = document.getElementById('SelecionarPlano').value

    if (SelectPlano === 'SeguroCarro') {
        formCasa.classList.add('d-none')
        formCarro.classList.remove('d-none')
    }
    else if (SelectPlano === 'SeguroCasa') {
        formCarro.classList.add('d-none')
        formCasa.classList.remove('d-none')
    }

}


