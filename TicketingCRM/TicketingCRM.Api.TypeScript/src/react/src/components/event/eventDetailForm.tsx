import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
            loaded: false,
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
      return <LoadingForm />;
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
							<div>address1</div>
							<div>{this.state.model!.address1}</div>
						 </div>
					   						 <div>
							<div>address2</div>
							<div>{this.state.model!.address2}</div>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>cityId</h3>
							<div>{this.state.model!.cityIdNavigation!.toDisplay()}</div>
						 </div>
					   						 <div>
							<div>date</div>
							<div>{this.state.model!.date}</div>
						 </div>
					   						 <div>
							<div>description</div>
							<div>{this.state.model!.description}</div>
						 </div>
					   						 <div>
							<div>endDate</div>
							<div>{this.state.model!.endDate}</div>
						 </div>
					   						 <div>
							<div>facebook</div>
							<div>{this.state.model!.facebook}</div>
						 </div>
					   						 <div>
							<div>name</div>
							<div>{this.state.model!.name}</div>
						 </div>
					   						 <div>
							<div>startDate</div>
							<div>{this.state.model!.startDate}</div>
						 </div>
					   						 <div>
							<div>website</div>
							<div>{this.state.model!.website}</div>
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
    <Hash>96115d8ef22a47f5ed9e11809d9690ca</Hash>
</Codenesium>*/