import { createCartItemTextbox, removeCartItemTextbox, createCartItem, createStoreLocationOption } from './ManipulateDOM_Elements.mjs';

"use strict"

console.log("Script started");

let itemInCart = function (id) {
    this.id = id;
    this.units = 0;
}

let totalPrice = 0.00;
let totalItems = 0;
let totalItemUnits = 0;

const refs = {};

const productDB = {
    products: [
        {
            id: 1,
            name: "Maggie",
            price: 20,
            availableUnits: 50
        },
        {
            id: 2,
            name: "Chocolate",
            price: 25,
            availableUnits: 50
        },
        {
            id: 3,
            name: "IceCream",
            price: 50,
            availableUnits: 50
        },
        {
            id: 4,
            name: "Blanket",
            price: 300,
            availableUnits: 50
        },
    ],
    deliveryLocations: [
        "Noida",
        "Gr. Noida",
        "Delhi",
        "Ghaziabad",
        "Meerut",
        "Lucknow"
    ]
};

let state = {
    deliveryDetails: {
        date: null,
        time: null,
        selLocation: null
    },
    cart: {
        products: []
    }
};

let getCurrentProductByName = (name) => {
    for (let product of productDB.products) {
        if (product.name == name)
            return product;
    }
}

let addEventListeners = function () {
    // for checkbox checked value toggle by clicking Checkboxes div
    for (let item of refs.saleDataItem) {
        item.addEventListener('click', function (e) {
            e.currentTarget.firstChild.click();
        });
    }

    // checkBox Handler, for adding, removing item textboxes 
    for (let currentCheckbox of refs.productCheckbox) {
        currentCheckbox.addEventListener('click', (e) => {
            e.stopPropagation();
            let currentProduct = getCurrentProductByName(currentCheckbox.value);
            if (currentCheckbox.checked) {
                createCartItemTextbox(currentProduct.name, currentProduct.price);

                let cartItem = new itemInCart(currentProduct.id);
                cartItem.units++;
                state.cart.products.push(cartItem);

                refs.labelTotalCartItems.innerText = ++totalItems;
                updateTotalUnits();

                for (let button of refs.incDecValueButton) {
                    button.addEventListener('click', plusMinusButtonsHandler);
                }
                for (let x of refs.itemUnitTextBoxes) {
                    x.addEventListener('input', itemUnitsChangedManually);
                }
            }
            else {
                let index = state.cart.products.findIndex(product => product.id == currentProduct.id);
                state.cart.products.splice(index, 1);
                console.log(state.cart.products);
                refs.labelTotalCartItems.innerText = --totalItems;
                removeCartItemTextbox(currentProduct.name);
                updateTotalUnits();
            }
        });
    }
}

function setUp() {
    // for creating Cart Items shown in Filter box
    productDB.products.forEach(product => createCartItem(product.name));

    // for adding store Location options in select Location dropdown menu
    productDB.deliveryLocations.forEach(location => createStoreLocationOption(location));

    grabRefrences();

    addEventListeners();
    //    loadState();
}
setUp();

function grabRefrences() {
    refs["labelTotalCartItems"] = document.querySelector("#totalCartItemsLabel");
    refs["labelTotalCartItemUnits"] = document.querySelector("#totalCartItemUnitsLabel");
    refs["labelTotalPrice"] = document.querySelector("#totalPriceLabel");
    refs["productCheckbox"] = document.querySelectorAll(".selectedDataItems");
    refs["incDecValueButton"] = document.getElementsByClassName("incDecValueButton");
    refs["itemUnitTextBoxes"] = document.getElementsByClassName("itemUnitTextBox");
    refs["saleDataItem"] = document.getElementsByClassName("saleDataItem");
    refs["formData"] = document.getElementById("salesDataForm");
}

// for adjusting item units using Plus Minus buttons
let plusMinusButtonsHandler = function () {
    let textBox = this.innerText === '+' ? this.previousElementSibling : this.nextElementSibling;
    let currentProduct = getCurrentProductByName(textBox.name);
    let currentCartItem = state.cart.products.find(item => item.id == currentProduct.id);
    if (this.innerText === '+') {
        textBox.value++;
    }
    else if (textBox.value > 0) {
        textBox.value--;
    }
    currentCartItem.units = parseInt(textBox.value);
    updateTotalUnits();
}

let itemUnitsChangedManually = function () {
    let currentProduct = getCurrentProductByName(this.name);
    let currentCartItem = state.cart.products.find(item => item.id == currentProduct.id);
    this.value = this.value == "" ? 0 : this.value * 1;
    currentCartItem.units = parseInt(this.value);
    updateTotalUnits();
}

let calculateTotalPrice = () => {
    totalPrice = 0.00;
    state.cart.products.forEach(cartItem => {
        let currentPrice = productDB.products.find(product => product.id == cartItem.id).price;
        totalPrice += cartItem.units * currentPrice;
    });
    refs.labelTotalPrice.innerText = totalPrice;
}

let updateTotalUnits = () => {
    totalItemUnits = 0.0;
    state.cart.products.forEach(product => totalItemUnits += product.units);
    refs.labelTotalCartItemUnits.innerText = totalItemUnits;
    calculateTotalPrice();
}

refs.formData.onsubmit = (e) => {
    e.preventDefault();
    let salesData = {
        "salesDate": e.target.salesDate.value,
        "salesTime": e.target.salesTime.value,
        "storeLocation": e.target.storeLocation.options[e.target.storeLocation.selectedIndex].value,
        "cartItems": [],
        "totalPrice": totalPrice
    }
    state.cart.products.forEach(cartItem => salesData.cartItems.push(cartItem));
    console.log(salesData);
}

// ProductCatalog {

// }

// productDB.products.forEach(p => productcatalog.add(new Product()));

// function syncState(){
//     syncDeliveryOptions();
// }

// function syncDeliveryOptions(){

// }

// function loadState(){
//     // localStorage[];
// }