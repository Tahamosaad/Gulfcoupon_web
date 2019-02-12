//@*<script src="/WebResource.axd?d=LJd0IFDVsLpp9Gb5F8IuqDWl5lVht7V7QiWmEg0XqlK36DO-hM0zUynV46FFq6TZhjUG3147oVcN1uU_G_UbNayIvuBoXUgCfTmdOdr5E7U1&amp;t=636681676740000000" type="text/javascript"></script>*@

//<script type="text/javascript">
////<![CDATA[

//WebForm_InitCallback();//]]>
//</script>
var theForm = document.forms['form1'];
if (!theForm) {
    theForm = document.form1;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//<![CDATA[
function CallServer(arg, context) { WebForm_DoCallback('__Page',arg,ReceiveServerData,context,null,false)} ;
var Criteria='ItemCode^^^=^^^09010101-109^^^^^^AND',CriteriaCap='Item Code = 09010101-109 AND';
function AddLine(){
    var F=findControl('ddlFields'),O=findControl('ddlOps'),V=findControl('txtValue'),S=findControl('ddlSort'),L=findControl('ddlLink'),SQL;
    SQL=F.selectedIndex+';'+O.options[O.selectedIndex].text+';'+V.value+';'+S.options[S.selectedIndex].text+';'+L.options[L.selectedIndex].text;
    CallServer(SQL,'');
}
function DelLine(){
    CallServer(findControl('lstCriteria').selectedIndex,'');
}
function ReceiveServerData(rValue){
    var C=findControl('lstCriteria');
    var arSplice=Criteria.split(';');
    var F=findControl('ddlFields'),O=findControl('ddlOps'),V=findControl('txtValue'),S=findControl('ddlSort'),L=findControl('ddlLink'),SQL;
    SQL=F.options[F.selectedIndex].text+' '+O.options[O.selectedIndex].text+' '+V.value+' '+S.options[S.selectedIndex].text+' '+L.options[L.selectedIndex].text;
    var i=C.selectedIndex;
    if (rValue=='0')
    {
        if (i > -1)
        {
            C.options[i]=null;
            arSplice.splice(i,1);
            Criteria=arSplice.join(';');
            arSplice=CriteriaCap.split(';');arSplice.splice(i,1);
            CriteriaCap=arSplice.join(';');
        }
        else
        {
            alert('Please select a line to delete.');
        }}
    else if (rValue.substring(0,1)=='0'){alert(rValue.substring(1));}
    else {C.options[C.options.length]=new Option(SQL,1);
        if (Criteria=='')
        {
            Criteria=rValue;
        }
        else{Criteria=Criteria+';'+rValue;
        }
        if (CriteriaCap=='')
        {
            CriteriaCap=SQL;
        }
        else{CriteriaCap=CriteriaCap+';'+SQL;
        }
    }}
function findControl(ControlID){
    var ret=null, aControls = document.getElementsByTagName('*');
    if (aControls){
        for (var i=0; i< aControls.length ; i++){
            if (aControls[i].id == ControlID){
                ret =aControls[i];break;}}}return ret;}
function OpenPopup(){
    var url, retval='',i, ddl=new Object(), T=new Object(), SQL;
    SQL="SELECT ItemCode, ItemName, PartNumber From ItemsDirectory ORDER BY ItemsDirectory.ItemCode; SELECT ItemName From ItemsDirectory ORDER BY ItemName; SELECT Cat1Code,Cat1Name From ItemCategory1 ORDER BY Cat1Code; SELECT Cat1Name From ItemCategory1 ORDER BY Cat1Name; SELECT Cat2Code,Cat2Name From ItemCategory2 ORDER BY Cat2Code; SELECT Cat2Name From ItemCategory2 ORDER BY Cat2Name; SELECT Cat3Code,Cat3Name From ItemCategory3 ORDER BY Cat3Code; SELECT Cat3Name From ItemCategory3 ORDER BY Cat3Name; SELECT Cat4Code,Cat4Name From ItemCategory4 ORDER BY Cat4Code; SELECT Cat4Name From ItemCategory4 ORDER BY Cat4Name; SELECT PersonCode As VendCode,PersonName As VendName FROM Persons Where(Active=1 AND PersonType=2) Order By PersonCode; SELECT PartNumber From ItemsDirectory ORDER BY PartNumber; SELECT GroupID, ItemGroup FROM ItemsGroups ORDER BY GroupID; SELECT ManufacturerCode,Manufacturer FROM Manufacturers ORDER BY ManufacturerCode; Select BranchCode, BranchName From BranchCodes Order By BranchCode;";
    ddl=findControl('ddlFields');
    i=ddl.selectedIndex;
    T=findControl('txtValue');
    SQL=SQL.split(';')[i];
    if(SQL!=''){
        url='Popuphost.aspx?SQL=' + SQL + '&Random=' + Math.random();
        retval= window.open(url, 'retval','height=520,width=790,location=no,addressbar=no ,toolbar=no,menubar=no,scrollbars=yes,resizable=yes');
        if(retval!='' && retval!=null){
        }}}
function OpenReport(){
    var url, i, ddl=new Object();
    url='ViewReport.aspx?Criteria=' + Criteria + '&CriteriaCap=' + CriteriaCap +'&ReportID=' + document.getElementById('txtRepID').childNodes[0].nodeValue + '&Dest=' + findControl('ddlDest').selectedIndex;
    //var W=window.open(url, '');
    var theForm = document.forms['form1'];
    theForm.submit();
}
function setTargetField(targetField) {
    window.focus();
    //document.getElementById("txtValue").innerText = targetField;
    document.getElementById('txtValue').value = targetField;

}
//]]>
