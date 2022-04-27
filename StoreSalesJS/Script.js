import { createCartItemTextbox, removeCartItemTextbox, createCartItem } from './BasicFunction.mjs';

console.log("Script started");
let cartItem = function (name, price) {
    this.name = name;
    this.price = price;
    this.units = 0;
}

let Maggie = new cartItem('Maggie', 20);
let Chocolate = new cartItem('Chocolate', 25);
let IceCream = new cartItem('IceCream', 50);
let Blanket = new cartItem('Blanket', 300);
let Mobile = new cartItem('Mobile', 20000);

let allCartItems = [Maggie, Chocolate, IceCream, Blanket, Mobile];
let totalPrice = 0.00;
let totalItems = 0;
let totalItemUnits = 0;

let dataItemCheckbox = document.getElementsByClassName("selectedDataItems");
let incDecValueButton = document.getElementsByClassName("incDecValueButton");
let totalCartItems = document.querySelector("#totalCartItems");
let totalCartItemUnits = document.querySelector("#totalCartItemUnits");
let totalPriceLabel = document.querySelector("#totalPriceLabel");
let formData = document.getElementById("salesDataForm");
let itemUnitTextBoxes = document.getElementsByClassName("itemUnitTextBox");
let saleDataItem = document.getElementsByClassName("saleDataItem");

// for creating Cart Items shown in Filter box
for (let item of allCartItems) {
    createCartItem(item.name,item.price);
}

// for checkbox checked value toggle by clicking Checkboxes div
for(let item of saleDataItem){
    item.addEventListener('click',function(e){
        e.currentTarget.firstChild.click();
    });
}

// checkBox Handler, for adding, removing item textboxes 
for (let x = 0; x < allCartItems.length; x++) {
    dataItemCheckbox[x].addEventListener('click', (e) => {
        e.stopPropagation();
        if (dataItemCheckbox[x].checked) {
            createCartItemTextbox(dataItemCheckbox[x].name, allCartItems[x].price);
            totalCartItems.innerText = ++totalItems;
            allCartItems[x].units++;
            updateTotalUnits();
            for (let x of incDecValueButton) {
                x.addEventListener('click', plusMinusButtonsHandler);
            }
            for (let x of itemUnitTextBoxes) {
                x.addEventListener('input', itemUnitsChangedHandler);
            }
        }
        else {
            let unitsRemoved = document.getElementsByName(dataItemCheckbox[x].name + "Units")[0].value;
            totalCartItems.innerText = --totalItems;
            removeCartItemTextbox(dataItemCheckbox[x].name);
            allCartItems[x].units-=unitsRemoved;
            updateTotalUnits();
        }
    });
}

// for adjusting item units using Plus Minus buttons
let plusMinusButtonsHandler = function () {
    let textBox = this.innerText === '+' ? this.previousElementSibling : this.nextElementSibling;
    let currentItem = allCartItems.filter(item => item.name == textBox.name.slice(0,-5));
    if (this.innerText === '+') {
        textBox.value++;
    }
    else if (textBox.value > 0) {
            textBox.value--;
    }
    currentItem[0].units = textBox.value;
    updateTotalUnits();
}

let itemUnitsChangedHandler = function() {
    let currentItem = allCartItems.filter(item => item.name == this.name.slice(0,-5));
    currentItem[0].units = this.value;
    updateTotalUnits();    
}

let calculateTotalPrice = () => {
    totalPrice = 0.00;
    for (let x in allCartItems) {
        if(dataItemCheckbox[x].checked)
        totalPrice += allCartItems[x].units * allCartItems[x].price;
    }
    totalPriceLabel.innerText = totalPrice;
}

let updateTotalUnits = () => {
    totalItemUnits = 0.0;
    for(let item of allCartItems){
        totalItemUnits += item.units*1;
        //console.log(item,item.units,totalItemUnits);    
    }
    totalCartItemUnits.innerText = totalItemUnits; 
    calculateTotalPrice();
}


formData.onsubmit = (e) => {
    e.preventDefault();
    console.log(e.target.salesDate.value);
    console.log(e.target.salesTime.value);
    console.log(e.target.storeLocation.options[e.target.storeLocation.selectedIndex].value);
    for (let x in allCartItems) {
        if(dataItemCheckbox[x].checked)
        {
            console.log(allCartItems[x].name);
            console.log("Price : " + allCartItems[x].price);
            console.log("Units : " + allCartItems[x].units);
        }
    }
    console.log("Total Price : " + totalPrice);
}

