// fetch method, returns es6 promises
import fetch from "isomorphic-fetch"
import "babel-polyfill"

// if (module.hot) {
//     module.hot.accept() // when app is updated
//     module.hot.dispose(() => { // re-run our app
//         app()
//     })
// }

const {cache, csp, fetch: _fetch, fp, hamt, lazy, meta, model, mux, ot, resource, router, store, vdom} = utils,
    {container, mount, rAF, update, qs, m} = vdom

const app = () => {
    // mount(() => m('div.test', 'hello world'), qs())
    console.log("hello from javascript!")
}

// fetch('/').then(r => r.text()).then(l => console.log(l))

app()

// Flow types supported
// function sum(a: number, b: number): number {
//     return a+b;
// }
//
// and runtime error checking is built-in
// sum(1, '2');