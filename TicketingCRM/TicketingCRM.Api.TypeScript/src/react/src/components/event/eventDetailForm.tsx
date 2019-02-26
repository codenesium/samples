import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface EventDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventDetailComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EventDetailComponent extends React.Component<
EventDetailComponentProps,
EventDetailComponentState
> {
  state = {
    model: new EventViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Events + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Events +
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
          let response = resp.data as Api.EventClientResponseModel;

          console.log(response);

          let mapper = new EventMapper();

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
							<h3>address1</h3>
							<p>{String(this.state.model!.address1)}</p>
						 </div>
					   						 <div>
							<h3>address2</h3>
							<p>{String(this.state.model!.address2)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>cityId</h3>
							<p>{String(this.state.model!.cityIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>date</h3>
							<p>{String(this.state.model!.date)}</p>
						 </div>
					   						 <div>
							<h3>description</h3>
							<p>{String(this.state.model!.description)}</p>
						 </div>
					   						 <div>
							<h3>endDate</h3>
							<p>{String(this.state.model!.endDate)}</p>
						 </div>
					   						 <div>
							<h3>facebook</h3>
							<p>{String(this.state.model!.facebook)}</p>
						 </div>
					   						 <div>
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>startDate</h3>
							<p>{String(this.state.model!.startDate)}</p>
						 </div>
					   						 <div>
							<h3>website</h3>
							<p>{String(this.state.model!.website)}</p>
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

export const WrappedEventDetailComponent = Form.create({ name: 'Event Detail' })(
  EventDetailComponent
);

/*<Codenesium>
    <Hash>6d1d750a26308bb8ef64e296ce33ddfe</Hash>
</Codenesium>*/