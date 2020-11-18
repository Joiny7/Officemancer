const initialState = {
    userLoggedIn: false
};

function reducer(state=initialState, action){
    switch(action.type){
        case "LOGGED_IN" : return { userLoggedIn: true }
        case "LOGGED_OUT" : return { userLoggedIn: false }
        default: return state
    }
}

export default reducer