




function set_default_vals() {

    let ratings = document.getElementById("rating");
    let edit_statuses = document.getElementById("edited");
    let current_rating = document.getElementById("rating_hidden")
    let current_edit = document.getElementById("edited_hidden")

  


    for (iCount = 0; iCount < ratings.options.length; iCount++) {
       
        if (current_rating.value == ratings.options[iCount].value) {
            ratings.options[iCount].selected = true;
        };
    };

    // ccheck status
    if (current_edit.value == "value") {
        current_edit = "True"
    }
    else {
        current_edit = "False"
    }

    for (iCount = 0; iCount < edit_statuses.options.length; iCount++) {
       
        if (current_edit == edit_statuses.options[iCount].value) {
            edit_statuses.options[iCount].selected = true;
        };
    };
   
};

set_default_vals()