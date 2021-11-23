function hoverLi(n,nm){

    for(var i=1;i<nm;i++){   //如果有N个标签,就将i<=N; 
        if(n==i){
            document.getElementById("BZ_2_1").style.display=(document.getElementById("BZ_2_1").style.display=='none')?'block':'none';
            document.getElementById("BZ_2").style.display='none';
            document.getElementById("IF2").style.display=(document.getElementById("IF2").style.display=='none')?'block':'none';
            document.getElementById("IF2").style.display="../UserPrice/UserSelect.aspx";

        }
        else{
            document.getElementById("BZ_2").style.display=(document.getElementById("BZ_2").style.display=='none')?'block':'none';
            document.getElementById("BZ_2_1").style.display='none';
            document.getElementById("IF2").style.display='none';
        }
    }
}
function hoverLi2(n,m)
{
    for(var i=1;i<m;i++){
        if(n==i){
        document.getElementById("Tab4").style.display=(document.getElementById("Tab4").style.display=='none')?'block':'block';
        document.getElementById("btnPriceA").style.display=(document.getElementById("btnPriceA").style.display=='block')?'none':'block';
        document.getElementById("BZ_1").style.display='none';
        document.getElementById("Tab4").style.display='none';
        }
        else{
            document.getElementById("BZ_2").style.display='none';
            document.getElementById("btnPriceB").style.display=(document.getElementById("btnPriceB").style.display=='none')?'block':'none';
            document.getElementById("myDivTwo").style.display='none';
        }
    }
}