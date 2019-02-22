import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkLogMapper from './linkLogMapper';
import LinkLogViewModel from './linkLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface LinkLogDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkLogDetailComponentState {
  model?: LinkLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LinkLogDetailComponent extends React.Component<
LinkLogDetailComponentProps,
LinkLogDetailComponentState
> {
  state = {
    model: new LinkLogViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.LinkLogs + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.LinkLogs +
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
          let response = resp.data as Api.LinkLogClientResponseModel;

          console.log(response);

          let mapper = new LinkLogMapper();

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
							<h3>DateEntered</h3>
							<p>{String(this.state.model!.dateEntered)}</p>
						 </div>
					   						 <div>
							<h3>Id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>LinkId</h3>
							<p>{String(this.state.model!.linkIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>Log</h3>
							<p>{String(this.state.model!.log)}</p>
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

export const WrappedLinkLogDetailComponent = Form.create({ name: 'LinkLog Detail' })(
  LinkLogDetailComponent
);

/*<Codenesium>
    <Hash>15662a2d8b76c97da2baa717837cb35b</Hash>
</Codenesium>*/