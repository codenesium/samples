import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallPersonMapper from './callPersonMapper';
import CallPersonViewModel from './callPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CallPersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallPersonDetailComponentState {
  model?: CallPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CallPersonDetailComponent extends React.Component<
  CallPersonDetailComponentProps,
  CallPersonDetailComponentState
> {
  state = {
    model: new CallPersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CallPersons + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CallPersons +
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
          let response = resp.data as Api.CallPersonClientResponseModel;

          console.log(response);

          let mapper = new CallPersonMapper();

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
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>note</h3>
              <p>{String(this.state.model!.note)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>personId</h3>
              <p>{String(this.state.model!.personIdNavigation!.toDisplay())}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>personTypeId</h3>
              <p>
                {String(this.state.model!.personTypeIdNavigation!.toDisplay())}
              </p>
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

export const WrappedCallPersonDetailComponent = Form.create({
  name: 'CallPerson Detail',
})(CallPersonDetailComponent);


/*<Codenesium>
    <Hash>f91ebb14432f4cd93e1641d4147ccca8</Hash>
</Codenesium>*/