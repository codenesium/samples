import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import LinkTypeViewModel from './linkTypeViewModel';
import LinkTypeMapper from './linkTypeMapper';

interface Props {
  model?: LinkTypeViewModel;
}

const LinkTypeEditDisplay = (props: FormikProps<LinkTypeViewModel>) => {
  let status = props.status as UpdateResponse<Api.LinkTypeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof LinkTypeViewModel] &&
      props.errors[name as keyof LinkTypeViewModel]
    ) {
      response += props.errors[name as keyof LinkTypeViewModel];
    }

    if (
      status &&
      status.validationErrors &&
      status.validationErrors.find(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )
    ) {
      response += status.validationErrors.filter(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )[0].errorMessage;
    }

    return response;
  };

  let errorExistForField = (name: string): boolean => {
    return errorsForField(name) != '';
  };

  return (
    <form onSubmit={props.handleSubmit} role="form">
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rwType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Type
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="rwType"
            className={
              errorExistForField('rwType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rwType') && (
            <small className="text-danger">{errorsForField('rwType')}</small>
          )}
        </div>
      </div>

      <button type="submit" className="btn btn-primary" disabled={false}>
        Submit
      </button>
      <br />
      <br />
      {status && status.success ? (
        <div className="alert alert-success">Success</div>
      ) : null}

      {status && !status.success ? (
        <div className="alert alert-danger">Error occurred</div>
      ) : null}
    </form>
  );
};

const LinkTypeEdit = withFormik<Props, LinkTypeViewModel>({
  mapPropsToValues: props => {
    let response = new LinkTypeViewModel();
    response.setProperties(props.model!.id, props.model!.rwType);
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<LinkTypeViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.rwType == '') {
      errors.rwType = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new LinkTypeMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.LinkTypes + '/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.LinkTypeClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'LinkTypeEdit',
})(LinkTypeEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface LinkTypeEditComponentProps {
  match: IMatch;
}

interface LinkTypeEditComponentState {
  model?: LinkTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LinkTypeEditComponent extends React.Component<
  LinkTypeEditComponentProps,
  LinkTypeEditComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.LinkTypes +
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
          let response = resp.data as Api.LinkTypeClientResponseModel;

          console.log(response);

          let mapper = new LinkTypeMapper();

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
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <LinkTypeEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b147ef9bf9096770e1e8222a47a7bd34</Hash>
</Codenesium>*/