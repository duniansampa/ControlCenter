var psDict = {};
function perfectScrollbarCreate(selector) {
    perfectScrollbarDestroy(selector)
    let container = document.querySelector(selector);
    psDict[selector] = new PerfectScrollbar(container);
}
function perfectScrollbarDestroy(selector) {
    if (psDict[selector] != undefined)
        psDict[selector].destroy();
}
