let createCartItemTextbox = function (labelName,price){
    let outerDiv = document.createElement("div");
    let label = document.createElement("label");
    let customizedTextBox = document.createElement("div");
    label.innerText = labelName + " 1 unit price : " + price;
    customizedTextBox.classList.add("customizedTextbox");
    outerDiv.id = "cartItem" + labelName;
    outerDiv.appendChild(label);
    outerDiv.appendChild(customizedTextBox);

    let minusButton = document.createElement("button");
    minusButton.classList.add("incDecValueButton","buttonMinus");
    minusButton.innerText = "-";
    minusButton.type = "button";
    
    let plusButton = document.createElement("button");
    plusButton.classList.add("incDecValueButton","buttonPlus");
    plusButton.innerText = "+";
    plusButton.type = "button";

    let textbox = document.createElement("input");
    textbox.type = "number";
    textbox.name = labelName + "Units";
    textbox.classList.add("itemUnitTextBox");
    textbox.value = 1;
    textbox.min = 0;

    customizedTextBox.appendChild(minusButton);
    customizedTextBox.appendChild(textbox);
    customizedTextBox.appendChild(plusButton);

    let dataItemTextBoxes = document.getElementsByClassName("dataItemTextboxes");
    dataItemTextBoxes[0].appendChild(outerDiv);
    
}

let removeCartItemTextbox = function(elementID) {
    let cartItem = document.getElementById("cartItem" + elementID);

    let dataItemTextBoxes = document.getElementsByClassName("dataItemTextboxes");
    dataItemTextBoxes[0].removeChild(cartItem);

}

let createCartItem = function(name,price){
    let outerDiv = document.createElement("div");
    outerDiv.classList.add("saleDataItem");
    
    let checkbox = document.createElement("input");
    checkbox.type = "checkbox";
        checkbox.classList.add("selectedDataItems");
        checkbox.name = name;
        checkbox.value = price;
        
        let label = document.createElement("label");
        label.innerText = name;
        
        outerDiv.appendChild(checkbox);
        outerDiv.appendChild(label);
        
        let salesDataItems = document.getElementsByClassName("salesDataItems");
        salesDataItems[0].appendChild(outerDiv);
    }


export { createCartItemTextbox, removeCartItemTextbox, createCartItem};