import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RetweetMapper from './retweetMapper';
import RetweetViewModel from './retweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface RetweetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RetweetDetailComponentState {
  model?: RetweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class RetweetDetailComponent extends React.Component<
RetweetDetailComponentProps,
RetweetDetailComponentState
> {
  state = {
    model: new RetweetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Retweets + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Retweets +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.RetweetClientResponseModel;

          console.log(response);

          let mapper = new RetweetMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>date</h3>
							<p>{String(this.state.model!.date)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>retwitter_user_id</h3>
							<p>{String(this.state.model!.retwitterUserIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>time</h3>
							<p>{String(this.state.model!.time)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>tweet_tweet_id</h3>
							<p>{String(this.state.model!.tweetTweetIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedRetweetDetailComponent = Form.create({ name: 'Retweet Detail' })(
  RetweetDetailComponent
);

/*<Codenesium>
    <Hash>dfe47a35e1497493fadc4b0a001d272d</Hash>
</Codenesium>*/