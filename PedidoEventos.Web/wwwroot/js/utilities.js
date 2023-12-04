function botaoMode() {
    if (document.documentElement.getAttribute("data-bs-theme") == "dark") {
        document.documentElement.setAttribute("data-bs-theme", "light");
    } else {
        document.documentElement.setAttribute("data-bs-theme", "dark");
    }
}

function removerCaracterEspecial(valor) {
    return valor.replace(/\D/g, "");
}

function formatarNumeroTelefone(numeroTelefone) {
    const telefoneLimpo = removerCaracterEspecial(numeroTelefone);

    if (telefoneLimpo.length < 3) return `${telefoneLimpo.slice(0, 2)}`;
    else if (telefoneLimpo.length < 7)
        return `(${telefoneLimpo.slice(0, 2)}) ${telefoneLimpo.slice(2)}`;
    else if (telefoneLimpo.length < 11)
        return `(${telefoneLimpo.slice(0, 2)}) ${telefoneLimpo.slice(
            2,
            6
        )}-${telefoneLimpo.slice(6)}`;
    else if (telefoneLimpo.length == 11)
        return `(${telefoneLimpo.slice(0, 2)}) ${telefoneLimpo.slice(
            2,
            3
        )}${telefoneLimpo.slice(3, 7)}-${telefoneLimpo.slice(7)}`;
    else return telefoneLimpo;
}

function formatarNumeroProcesso(numeroProcesso) {
    const processoLimpo = removerCaracterEspecial(numeroProcesso);
    if (processoLimpo.length < 8) return `${processoLimpo.slice(0, 7)}`;
    else if (processoLimpo.length < 10)
        return `${processoLimpo.slice(0, 7)}-${processoLimpo.slice(7)}`;
    else if (processoLimpo.length < 14)
        return `${processoLimpo.slice(0, 7)}-${processoLimpo.slice(
            7,
            9
        )}.${processoLimpo.slice(9)}`;
    else if (processoLimpo.length < 15)
        return `${processoLimpo.slice(0, 7)}-${processoLimpo.slice(
            7,
            9
        )}.${processoLimpo.slice(9, 13)}.${processoLimpo.slice(13)}`;
    else if (processoLimpo.length < 17)
        return `${processoLimpo.slice(0, 7)}-${processoLimpo.slice(
            7,
            9
        )}.${processoLimpo.slice(9, 13)}.${processoLimpo.slice(
            13,
            14
        )}.${processoLimpo.slice(14)}`;
    else if (processoLimpo.length < 21)
        return `${processoLimpo.slice(0, 7)}-${processoLimpo.slice(
            7,
            9
        )}.${processoLimpo.slice(9, 13)}.${processoLimpo.slice(
            13,
            14
        )}.${processoLimpo.slice(14, 16)}.${processoLimpo.slice(16)}`;
    else return processoLimpo;
}

function formatarDocumento(documento) {
    const documentoLimpo = removerCaracterEspecial(documento);

    if (documentoLimpo.length < 4) return documentoLimpo;
    else if (documentoLimpo.length < 7)
        return `${documentoLimpo.slice(0, 3)}.${documentoLimpo.slice(3)}`;
    else if (documentoLimpo.length < 10)
        return `${documentoLimpo.slice(0, 3)}.${documentoLimpo.slice(
            3,
            6
        )}.${documentoLimpo.slice(6)}`;
    else if (documentoLimpo.length < 12)
        return `${documentoLimpo.slice(0, 3)}.${documentoLimpo.slice(
            3,
            6
        )}.${documentoLimpo.slice(6, 9)}-${documentoLimpo.slice(9)}`;
    else if (documentoLimpo.length < 13)
        return `${documentoLimpo.slice(0, 2)}.${documentoLimpo.slice(
            2,
            5
        )}.${documentoLimpo.slice(5, 8)}/${documentoLimpo.slice(8)}`;
    else if (documentoLimpo.length <= 15)
        return `${documentoLimpo.slice(0, 2)}.${documentoLimpo.slice(
            2,
            5
        )}.${documentoLimpo.slice(5, 8)}/${documentoLimpo.slice(
            8,
            12
        )}-${documentoLimpo.slice(12)}`;
    else return documentoLimpo;
}

function formatarData(data) {
    // 01/01/2020
    const dataLimpo = removerCaracterEspecial(data);
    if (dataLimpo.length < 3) return dataLimpo;
    else if (dataLimpo.length < 5)
        return `${dataLimpo.slice(0, 2)}/${dataLimpo.slice(2)}`;
    else
        return `${dataLimpo.slice(0, 2)}/${dataLimpo.slice(
            2,
            4
        )}/${dataLimpo.slice(4, 8)}`;
}

function formatarDinheiro(valor, digitado) {
    let valorProcesso = 0;
    if (digitado) {
        valorProcesso = removerCaracterEspecial(valor);
        if (valorProcesso > 0) {
            valor = new Intl.NumberFormat("pt-BR", {
                style: "currency",
                currency: "BRL",
            }).format(valorProcesso / 100);
            return valor;
        }
    } else {
        valorProcesso = valor;
        if (valorProcesso > 0) {
            valor = new Intl.NumberFormat("pt-BR", {
                style: "currency",
                currency: "BRL",
            }).format(valorProcesso);
            return valor;
        }
    }
}

function obterIdade(birthDate) {
    const parts = birthDate.split("/");
    const day = parseInt(parts[0], 10);
    const month = parseInt(parts[1], 10);
    const year = parseInt(parts[2], 10);

    const today = new Date();

    let idade = today.getFullYear() - year;

    if (
        today.getMonth() < month ||
        (today.getMonth() === month && today.getDate() < day)
    ) {
        idade--;
    }

    return idade;
}

function deepEqual(objA, objB) {
    const keysA = Object.keys(objA);
    const keysB = Object.keys(objB);

    if (keysA.length !== keysB.length) {
        return false;
    }

    for (const key of keysA) {
        if (objA[key] !== objB[key]) {
            return false;
        }
    }

    return true;
}

function isNullOrEmptyOrZero(value) {
    return (
        value === null ||
        value === "" ||
        value === 0 ||
        value === undefined ||
        value === "0"
    );
}

function copyToClipboard(el) {
    var copyText = el.parentElement.querySelector(".target__copy").innerText;

    navigator.clipboard
        .writeText(copyText)
        .then(function () {
            el.classList.add("on__copying");
            setTimeout(function () {
                el.classList.remove("on__copying");
            }, 1500);
        })
        .catch(function (error) {
            console.error(
                "Erro ao copiar para a �rea de transfer�ncia:",
                error
            );
        });
}

function obterCssPorCorId(cor) {
    switch (cor) {
        case 1:
            return "text-bg-primary";
        case 2:
            return "text-bg-danger";
        case 3:
            return "text-bg-warning";
        case 4:
            return "text-bg-secondary";
        case 5:
            return "text-bg-success";
        default:
            return "text-bg-light";
    }
}
