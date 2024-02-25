function validateForm() {

    var res = true;

    res = firstNameVal() && res;
    res = lastNameVal() && res;
    res = userNameVal() && res;
    res = passwordVal() && res;
    res = confirmemail() && res;
    res = confirmPhone() && res;

    return res;

}

function firstNameVal() {
    var firstName = document.getElementById("firstName").value;
    var msgBox = document.getElementById("firstNameMsg");
    var reg = /[0-9]/;
    var reg1 = /\W/;
    var reg2 = /\s/;
    if (firstName.length == 0) {
        msgBox.innerHTML = "You must enter first name";
        return false;
    }
    if (reg.test(firstName) || reg1.test(firstName) || reg2.test(firstName)) {
        msgBox.innerHTML = "first name cant include numbers, spaces or speical chars";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function lastNameVal() {
    var lastName = document.getElementById("lastName").value;
    var msgBox = document.getElementById("lastNameMsg");
    var reg = /[0-9]/;
    var reg1 = /\W/;
    var reg2 = /\s/;
    if (lastName.length == 0) {
        msgBox.innerHTML = "You must enter last name";
        return false;
    }
    if (reg.test(lastName) || reg1.test(lastName) || reg2.test(lastName)) {
        msgBox.innerHTML = "last name cant include numbers, spaces or speical chars";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function userNameVal() {
    var userName = document.getElementById("userName").value;
    var msgBox = document.getElementById("userNameMsg");
    if (userName.length == 0) {
        msgBox.innerHTML = "You must enter user name";
        return false;
    }
    if (!isLetter(userName[0])) {
        msgBox.innerHTML = "User name must start with a letter ";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function passwordVal() {
    var pass = document.getElementById("password").value;
    var msgBox = document.getElementById("passwordMsg");
    if (pass.length < 7) {
        msgBox.innerHTML = "password must contain at least 7 charactes";
        return false;
    }
    var specialChar = /[@!#$%^&*()-+]/; //regular Expretion
    if (!specialChar.test(pass)) {
        msgBox.innerHTML = "password must contain one special char";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function confirmFun() {
    var pass = document.getElementById("password").value;
    var confirm = document.getElementById("confirm").value;
    var msgBox = document.getElementById("confirmMsg");

    if (pass != confirm) {
        msgBox.innerHTML = "confirm password doesn't mutch password";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function confirmemail() {
    var email = document.getElementById("email").value;
    var msgBox = document.getElementById("emailMsg");

    var reg = /^\w+/;
    if (!reg.test(email)) {
        msgBox.innerHTML = "mail must start with letter or digit";
        return false;
    }
    msgBox.innerHTML = "";
    reg = /^\w+([\.-]?\w+)/;
    if (!reg.test(email)) {
        msgBox.innerHTML = "mail can have only one [. or -] following letter ";
        return false;
    }
    msgBox.innerHTML = "";
    reg = /^\w+([\.-]?\w+)*@/;
    if (!reg.test(email)) {
        msgBox.innerHTML = "mail must have @";
        return false;
    }
    msgBox.innerHTML = "";
    reg = /^\w+([\.-]?\w+)*@\w+/;
    if (!reg.test(email)) {
        msgBox.innerHTML = "you need letters after @";
        return false;
    }
    msgBox.innerHTML = "";

    reg = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)(\.\w{2,4})+$/;
    if (!reg.test(email)) {
        msgBox.innerHTML = "Invalid email";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function confirmPhone() {
    var phone = document.getElementById("phone").value;
    var msgBox = document.getElementById("phoneMsg");

    var reg = /^0{1}(2|3|4|6|8|9|5[0|(2-8)]|73)-?[1-9]\d{6}$/;
    if (!reg.test(phone)) {
        msgBox.innerHTML = "phone number is illegal";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function cityVal() {
    var city = document.getElementById("city").value;
    var msgBox = document.getElementById("cityMsg");
    var reg = /[0-9]/;
    var reg1 = /\W/;
    var reg2 = /\s/;
    if (city.length == 0) {
        msgBox.innerHTML = "You must enter city";
        return false;
    }
    if (reg.test(city) || reg1.test(city) || reg2.test(city)) {
        msgBox.innerHTML = "city cant include numbers, spaces or speical chars";
        return false;
    }
    msgBox.innerHTML = "";
    return true;
}

function isDigit(ch) {
    if (ch >= "0" && ch <= "9")
        true;
    false;
}

function isLetter(ch) {
    if ((ch >= "a" && ch <= "z") || (ch >= "A" && ch <= "Z"))
        return true;
    return false;
}

function sequence(str) {
    // check for sequence of three characters;
    var seq = false;
    var a, b, c;
    for (var i = 1; i < str.length - 1; i++) {
        a = str.charCodeAt(i - 1);
        b = str.charCodeAt(i);
        c = str.charCodeAt(i + 1);


        if (a + 1 == b && b + 1 == c) {
            return true;
        }

    }
    return seq;
}

function confirm() {

    var con = document.getElementById("confirm").value;
    var pass = document.getElementById("pass").value;

    if (!(con == pass)) {
        document.getElementById("msgBox").innerHTML = "doesnt ...."
        return false;
    }
    return true;
}

function seq(str) {

    for (var i = 0; i < str.length - 2; i++) {

        if (str[i] == str[i + 1] && str[i] == str[i + 2]) {
            return false;
        }
    }
    return true;
}