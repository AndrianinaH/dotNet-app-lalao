/**
 * Created by kevin on 22/11/2018.
 */
function userConnected() {
    setTimeout(function () {
        $.ajax({
            url: "/Tchat/UserDisponible",
            success: function (rep) {
                createListUserConnected(rep);
            }
        });
        userConnected();
    }, 1000)
};

function createListUserConnected(liste) {
    var i;
    var div = "";
    for (i = 0; i < liste.length; i++) {
        div += '<li class="no-padding"><a href="/Tchat/Index/' + liste[i].Id + '" >' +
            '<i class="material-icons">grade</i>' + liste[i].Nom + '</a></li>';
    }
    $("#user-connected").empty();
    $("#user-connected").append(div);
}