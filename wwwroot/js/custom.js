$(function () {

    // derop down functions from materialize
    $('.dropdown-trigger').dropdown();
    // side-nav function from materialize
    $('.sidenav').sidenav();
    // tab function from materialize
    $('.tabs').tabs();
    // accordion function from materialize
    $('.collapsible').collapsible();
    // chips function from materialize
    //$('.chips').chips();

    //$(".chips").tagit();




    //$('.chips').material_chip({
    //    placeholder: 'You Emotions'
    //});

    //$('.chips').on('click', function () {
    //    let chipsObjectValue = $('#chips').material_chip('data');
    //    $.each(chipsObjectValue, function (key, value) {
    //        alert(key + ": " + value.tag);
    //    });
    //});
    // chips function from materialize
    $('select').formSelect();
    
    // pickers function from materialize
    $('.timepicker').timepicker();
    $('.datepicker').datepicker();
    // textarea function from materialize
    //$('textarea').characterCounter();
    //M.textareaAutoResize($('textarea'));
});


function toggleElement(e) {
    var toggle = $(e).data("class");
    $(e).toggleClass(toggle);
    sideMenu(toggle);
    wrapper(toggle);
}
function sideMenu(toggle){
    $("#Side-bar").toggleClass( 'menu-' +toggle);    
}

function wrapper(toggle){
    $("#Wrapper").toggleClass( 'menu-' +toggle);    
}