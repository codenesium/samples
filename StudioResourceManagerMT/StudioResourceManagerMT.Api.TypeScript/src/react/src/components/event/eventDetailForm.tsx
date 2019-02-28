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
							<h3>actualEndDate</h3>
							<p>{String(this.state.model!.actualEndDate)}</p>
						 </div>
					   						 <div>
							<h3>actualStartDate</h3>
							<p>{String(this.state.model!.actualStartDate)}</p>
						 </div>
					   						 <div>
							<h3>billAmount</h3>
							<p>{String(this.state.model!.billAmount)}</p>
						 </div>
					   						 <div>
							<h3>eventStatusId</h3>
							<p>{String(this.state.model!.eventStatusId)}</p>
						 </div>
					   						 <div>
							<h3>id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>scheduledEndDate</h3>
							<p>{String(this.state.model!.scheduledEndDate)}</p>
						 </div>
					   						 <div>
							<h3>scheduledStartDate</h3>
							<p>{String(this.state.model!.scheduledStartDate)}</p>
						 </div>
					   						 <div>
							<h3>studentNotes</h3>
							<p>{String(this.state.model!.studentNote)}</p>
						 </div>
					   						 <div>
							<h3>teacherNotes</h3>
							<p>{String(this.state.model!.teacherNote)}</p>
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
    <Hash>02552f5bc1642755463154aedd8f7260</Hash>
</Codenesium>*/