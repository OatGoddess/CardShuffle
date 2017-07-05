class CardTable extends React.Component {
    constructor(props, context) {
        super(props, context);

        this.state = { cards: [] };

        this.sort();

        this.sort = this.sort.bind(this);
        this.shuffle = this.shuffle.bind(this);
    };

    shuffle() {
        let url = "/shuffle";
        let xhr = new XMLHttpRequest();
        xhr.open('get', url, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ cards: data });
        }.bind(this);
        xhr.send();
    };

    sort() {
        let url = "/sort";
        let xhr = new XMLHttpRequest();
        xhr.open('get', url, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ cards: data });
        }.bind(this);
        xhr.send();
    };

    renderShiftwise() {
        return this.state.cards.map(function (elem) {
            return (
                <Card key={elem.suit + elem.value} suit={elem.suit} value={elem.value} />
            );
        });
    };

    render() {
        return (
            <div className='panel panel-main'>
                <div className='panel-heading'>
                    <CardControls shuffle={this.shuffle} sort={this.sort}/>
                </div>
                <div className='panel-body'>
                    <div className='row'>{this.renderShiftwise()}</div>
                </div>
            </div>
        )
    };
};

class CardControls extends React.Component {
    render() {
        return (
            <div className="col-lg-12">
                <div className="col-lg-6 col-xs-6">
                    <button className="center-block" onClick={this.props.shuffle}>Shuffle</button>
                </div>
                <div className="col-lg-6 col-xs-6">
                    <button className="center-block" onClick={this.props.sort}>Sort</button>
                    </div>
            </div>
            );
    };
};

class Card extends React.Component {
    render() {
        let imageName = "/images/cards/" + this.props.value + "_of_" + this.props.suit + ".svg";
        return (
            <div className="col-lg-3 col-xs-6">
                <img className="center-block" src={imageName} height="168" max-width="120"/>
            </div>
        )
    }
};

ReactDOM.render(
    <CardTable />,
    document.getElementById('content')
);