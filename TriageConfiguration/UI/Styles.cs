namespace TriageConfiguration.UI
{
    public class Styles
    {
        public List<string> StyleList = new();

        public Styles()
        {
            StyleList = new List<string>()
            {
                TextStyleCriteria,
                TextStyleTittle,
                TextStyleRuleset,
                TextStyleYES,
                TextStyleNO,
                TextStyleResultDescription,
                TextStyleResultBools,
                TextStyleDefaultResultBools,
                TextStyleDefaultResult,
                Diamond,
                Rectangle,
                DefaultRectangle,
                DefaultResultTittle,
                LineByLineResultText,
                ArrowRight,
                ArrowDown
            };
        }

        public readonly string TextStyleCriteria = @"
        <style>
            .centerCriteria {
                text-align:center;
                position: absolute;
                font-size: 0.9em;
                font-weight: bold;
                width: 200px;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
            }";

        public readonly string TextStyleTittle = @"
            .tittleStyle {
                text-align:center;
                position: relative;
                font-size: 1.2em;
                text-shadow: 0 0 3px #ff0000;
                font-weight: bold;
                margin-bottom:40px;
                line-height: 0.4;
                letter-spacing: -1px;
                word-spacing: 0px;
            }";

        public readonly string TextStyleRuleset = @"
            .centerRuleSet {
                position: relative;
                bottom: -10px;
                right: 70px;

            }";

        public readonly string TextStyleYES = @"
            .yes {
                position: relative;
                top: -140px;
                font-weight: bold;
            }";

        public readonly string TextStyleNO = @"

            .no {
                position: relative;
                top: 100px;
                right: 20px;
                font-weight: bold;
            }";

        public readonly string TextStyleResultDescription = @"
            .resultDescription {
                position: relative;
                font-size: 0.8em;
                bottom: 0px;
            }";

        public readonly string TextStyleResultBools = @"
            .resultBools {
                position: relative;
                font-size: 0.8em;
                top: 10px;
            }";

        public readonly string TextStyleDefaultResultBools = @"
            .resultDefaultBools {
                position: relative;
                font-size: 1em;
                top: 10px;
            }";

        public readonly string TextStyleDefaultResult = @"
            .defaultResult {
                position: relative;
                font-size: 0.7em;
            }";

        public readonly string Diamond = @"
            .diamond{
                position: relative;
                height: 200px;
                width: 200px;
                text-align:center;
                line-height: 0.3;
                letter-spacing: -1px;
                word-spacing: 0px;
                margin-top:-80px;
                margin-left: -800px;
            }
            .diamond:before {
                position: absolute;
                content: '';
                top: 0px;
                left: 0px;
                height: 100%;
                width: 100%;
                border: 1px solid orange;
                transform: rotateX(45deg) rotateZ(45deg);
                box-shadow: 0px 0px 7px gray;
            }
            .diamond:after {
                position: absolute;
                top: 1px;
                left: 1px;
                content: '';
                height: calc(100% - 1px); 
                width: calc(100% - 1px);
                transform: rotateX(45deg) rotateZ(45deg);
            }";

        public readonly string Rectangle = @"
            .rect{
              text-align:center;
              background-color:rgba(3,78,136,0.7);
              width:330px;
              height:150px;
              font-size: 1em;
              color:white;
              margin-left: 900px;
              position:relative;
              bottom: 230px;
            }
            .rect:before {
                position: absolute;
                content: '';
                top: 0px;
                left: 0px;
                height: 100%;
                width: 100%;
                box-shadow: 0px 0px 7px gray;
            }";

        public readonly string DefaultRectangle = @"
            .rectDefault{
              text-align:center;
              background-color:rgba(3,78,136,0.7);
              width:330px;
              right: 390px;
              height:150px;
              bottom: 120px;
              line-height: 1;
              letter-spacing: 0px;
              word-spacing: 0px;
              font-size: 1em;
              color:white;
              position:relative;
            }
            .rectDefault:before {
                position: absolute;
                content: '';
                top: 0px;
                left: 0px;
                height: 100%;
                width: 100%;
                box-shadow: 0px 0px 7px gray;
            }";

        public readonly string DefaultResultTittle = @"
            .defaultResultTittle {
              position: relative;
              bottom: 110px;
              right: 480px;
            }";

        public readonly string LineByLineResultText = @"
            .lineByLine {
              position: relative;
              color: black;
              font-size: 0.9em;
              font-weight: bold;
              top: 15px;
            }";

        public readonly string ArrowRight = @"
            .arrowRight {
              position: relative;
              width: 522px;
              border: 0.1px solid #000000;
              bottom: 100px;
              right: -10px;
            }
            
            .arrowRight::after {	
              content: '';
              width: 0; 
              height: 0; 
              border-top: 10px solid transparent;
              border-bottom: 10px solid transparent;
              border-left: 15px solid black;
              position: absolute;
              right: -10px;
              top: -10px;
            }";

        public readonly string ArrowDown = @"
            .arrowDown {
              position: relative;
              height:125px;
              display:inline-block;
              border: 0.5px solid #000000;
              top: 182px;
              left: 1px;
            } 
            .arrowDown::after {	
              content: '';
              width: 0; 
              height: 0; 
              border-top: 10px solid transparent;
              border-bottom: 10px solid transparent;
              border-left: 15px solid black;
              position: absolute;
              right: -7.5px;
              bottom: -7px;
              transform: rotate(90deg);
            }  
        </style>";
    }
}
