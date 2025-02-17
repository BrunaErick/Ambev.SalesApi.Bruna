$(document).ready(function () {
   

    // Função para obter todos os produtos
    function getAllProducts() {
        $.ajax({
            url: 'https://localhost:7181/api/products/GetAllProducts',  // Endereço da sua API
            type: 'GET',  // Método HTTP (GET para obter dados)
            dataType: 'json',  // Tipo de dados esperados da resposta
            success: function (response) {
                // Verificar se a resposta da API foi bem-sucedida
                if (response.success) {
                    // A API retornou sucesso, então vamos trabalhar com a lista de produtos
                   
                    var productList = response.data.data; // Acessa a lista de produtos
                    if (productList.length > 0) {
                        // Aqui você pode processar os produtos e exibi-los na página
                        var html = '';
                        productList.forEach(function (product) {
                            html += '<div class="product">';
                            html += '<img src="/img/' + product.image + '" class="imgProduct" />'; // Usando a imagem do produto
                            html += '<p class="productDescription">' + product.description + '</p>';
                            html += '<p id="qtde" class="qtde">Qtde</p>';
                            html += '<input type="text" id="tdeTxt' + product.id + '" class="qtdeTxt" />'; // Identificador único para cada produto
                            html += '<div id="btnAddProductCart' + product.id + '" class="addCart">Adicionar</div>'; // Botão de adicionar com id único
                            html += '</div>';
                        });
                        $('#products').html(html); 

                        $('.qtdeTxt').on('input', function () {
                            // Remove qualquer coisa que não seja número
                            $(this).val($(this).val().replace(/\D/g, ''));
                        });

                        $('.qtdeTxt').attr('maxlength', '2');
                    }
                } else {
                    // Caso a resposta tenha sucesso, mas não haja dados
                    console.log('Não foi possível encontrar produtos.');
                }
            },
            error: function (xhr, status, error) {
                console.log(JSON.stringify(xhr, null, 2));

            }
        });
    }

    // Chama a função ao carregar a página
    getAllProducts();
});
