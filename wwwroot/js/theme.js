// window.themeManager = {
//     toggle: function () {
//         const html = document.documentElement;

//         const isDark = html.getAttribute("data-theme") === "dark";

//         if (isDark) {
//             html.removeAttribute("data-theme");
//             return false;
//         }

//         html.setAttribute("data-theme", "dark");
//         return true;
//     }
// };

window.themeManager = {
    toggle: function () {
        const html = document.documentElement;

        const isDark = html.getAttribute("data-theme") === "dark";

        html.setAttribute(
            "data-theme",
            isDark ? "light" : "dark"
        );

        return !isDark;
    }



};


window.languageManager = {
    setLanguage: function (language) {
        document.documentElement.lang = language;
        document.documentElement.dir =
            language === "ar" ? "rtl" : "ltr";

        localStorage.setItem("linkgate-language", language);
    }
};