$("#manageCategoriesBtn").on("click", function () {
    $("#categories").removeClass("d-none");
    $("#backToTransactionsBtn").removeClass("d-none");
    $("#records").addClass("d-none");
    $("#openTransactionModalBtn").addClass("d-none");
    $("#openCategoryModalBtn").removeClass("d-none");
    $("#manageCategoriesBtn").addClass("d-none");
});

$("#backToTransactionsBtn").on("click", function () {
    $("#categories").addClass("d-none");
    $("#backToTransactionsBtn").addClass("d-none");
    $("#records").removeClass("d-none");
    $("#openTransactionModalBtn").removeClass("d-none");
    $("#openCategoryModalBtn").addClass("d-none");
    $("#manageCategoriesBtn").removeClass("d-none");
});

$("#openTransactionModalBtn").on("click", function () {
    console.log('t modal');
    $("#addTransactionModal").modal("show");
});

$(".openUpdateTransactionModalBtn").on("click", function () {
    var id = $(this).closest('tr').find('td:first').html();
    var date = $(this).closest('tr').find('td:eq(1) .transaction-date').html();
    var amount = $(this).closest('tr').find('.transaction-amount div').html();
    var name = $(this).closest('tr').find('#transaction-name').html();
    var categoryId = $(this).closest('tr').find('td:eq(4)').html();
    var transactionType = $(this).closest('tr').find('#transaction-type').html();

    console.log($.trim(date));

    $('#insert-transaction-form #InsertTransaction_Id').val($.trim(id));
    $('#insert-transaction-form #InsertTransaction_Date').val($.trim(date));
    $('#insert-transaction-form #InsertTransaction_Amount').val($.trim(amount).slice(1, -1));
    $('#insert-transaction-form #InsertTransaction_Name').val($.trim(name));
    $(`#insert-transaction-form #InsertTransaction_CategoryId option[value=${categoryId}]`).attr('selected', 'selected');
    $('#insert-transaction-form #InsertTransaction_TransactionType').find(`option:contains('${$.trim(transactionType)}')`).attr('selected', 'selected');

    $("#addTransactionModal").modal("show");
});

$(".openDeleteTransactionModalBtn").on("click", function () {
    var id = $(this).closest('tr').find('td:first').html();
    $('#deleteTransactionForm').append(`<input type="hidden" name="id" value="${id}">`);
    $("#deleteTransactionModal").modal("show");
});
