window.publicNavbar = {

    toggle: function () {

        const menu = document.getElementById("publicNavbar");
        const button = document.querySelector(".navbar-toggle");

        if (!menu || !button)
            return;

        const isOpen = menu.classList.toggle("is-open");

        button.classList.toggle("is-open", isOpen);

        button.setAttribute(
            "aria-expanded",
            isOpen.toString()
        );
    },

    close: function () {

        const menu = document.getElementById("publicNavbar");
        const button = document.querySelector(".navbar-toggle");

        if (!menu || !button)
            return;

        menu.classList.remove("is-open");
        button.classList.remove("is-open");

        button.setAttribute(
            "aria-expanded",
            "false"
        );
    }
};